using AutoMapper;
using Azure;
using Consultorio.Entities;
using Consultorio.Models.Request;
using Consultorio.Models.Responses;
using Consultorio.Repository.Errors;
using Consultorio.Repository.UnitOfWork.Interfaces;
using Consultorio.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Services.Implementation
{
    public class PractitionerServices : IPractitionerServices
    {
        private readonly PractitionerUnitOfWork _practitionerUnitOfWork;
        private readonly ILogger<PractitionerServices> _logger;
        private readonly IMapper _mapper;

        public PractitionerServices(PractitionerUnitOfWork practitionerUnitOfWork,
            ILogger<PractitionerServices> logger,
            IMapper mapper)
        {
            _practitionerUnitOfWork = practitionerUnitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<BaseResponseGeneric<Guid>> AddAsync(PractitionerDtoRequest practitionerDtoRequest)
        {
            var response = new BaseResponseGeneric<Guid>();
            try
            {
                var practitioner = _mapper.Map<Practitioner>(practitionerDtoRequest);
                _practitionerUnitOfWork.PractitionerRepository.Add(practitioner);
                await _practitionerUnitOfWork.CommitAsync();

                response.IsSucess(
                    sucess: response.Success = true,
                    data: response.Data = practitioner.Id);

            }
            catch (Exception ex)
            {

                string ErrorMessage = "An error ocurred while trying to add the practitioner";
                _logger.LogCritical(ex, "{ErrorMessage}{Message}", ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse> DeleteAsync(Guid id)
        {
            var response = new BaseResponse();
            try
            {

                var practitioner= await FindByIdAsNoTrackingAsync(id);
                if(!practitioner.Success)
                {
                    return response.Failure(PractitionerErrors.NotFound(id));
                }

                _practitionerUnitOfWork.PractitionerRepository.Delete(_mapper.Map<Practitioner>(practitioner.Data)); 
                await _practitionerUnitOfWork.CommitAsync();
                response.IsSuccess(succes: response.Success = true);
            }
            catch (Exception ex)
            {

                string ErrorMessage = "An error ocurred while trying to delete the practitioenr";
                _logger.LogCritical(ex, "{ErrorMessage}{Message}", ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponseGeneric<PractitionerDtoResponse>> FindByIdAsNoTrackingAsync(Guid id)
        {
            var response = new BaseResponseGeneric<PractitionerDtoResponse>();
            try
            {

                var practitioner = await _practitionerUnitOfWork.PractitionerRepository.FindByIdAsNoTrackingAsync(id);
                if (practitioner is null)
                {
                    response.Failure(sucess: false, errorMessage: PractitionerErrors.NotFound(id));
                }

                response.IsSucess(sucess: true, data: _mapper.Map<PractitionerDtoResponse>(practitioner));

 
            }
            catch (Exception ex)
            {

                string ErrorMessage = "An error ocurrec whlie trying to find the practitioner";
                _logger.LogCritical(ex, "{ErrorMessage}{Message}", ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponseGeneric<PractitionerDtoResponse>> FindByIdAsync(Guid id)
        {
            var response = new BaseResponseGeneric<PractitionerDtoResponse>();
            try
            {

                var practitioner = await _practitionerUnitOfWork.PractitionerRepository.FindByIdAsync(id);
                if (practitioner is null)
                {
                    return response.Failure(sucess: true,errorMessage:PractitionerErrors.NotFound(id));
                   
                }

                response.IsSucess(
                    sucess: response.Success = true, 
                    data: response.Data = _mapper.Map<PractitionerDtoResponse>(practitioner));


            }
            catch (Exception ex)
            {

                string ErrorMessage = "An error ocurred while trying to find the practitioner";
                _logger.LogCritical(ex, "{ErrorMessage}{Message}",ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<CollectionBaseResponseGeneric<PractitionerDtoResponse>> ListAsync()
        {
            var resposne = new CollectionBaseResponseGeneric<PractitionerDtoResponse>();

            try
            {
                var practitionersList = await _practitionerUnitOfWork.PractitionerRepository.ListAsync();


                resposne.ISuccess(sucess: true, data: resposne.Data = _mapper.Map<ICollection<PractitionerDtoResponse>>(practitionersList));




            }
            catch (Exception ex)
            {

                string ErrorMessage = "An error ocurred while trying to list the practitioners";
                _logger.LogCritical(ex, "{ErrorMessage}{Message}",ErrorMessage, ex.Message);
            }
            return resposne;
        }

        public async Task<BaseResponse> LogicDeleteAsync(Guid id)
        {
            var response = new BaseResponse();
            try
            {

                var practitioner = await FindByIdAsync(id);
                if (!practitioner.Success)
                {
                    return response.Failure(errorMessage: PractitionerErrors.NotFound(id));
                }

                await _practitionerUnitOfWork.PractitionerRepository.LogicDelete(id);
                await _practitionerUnitOfWork.CommitAsync();
                
            }
            catch (Exception ex)
            {

                string ErrorMessage = "An error ocurred while trying to delete the practitioenr";
                _logger.LogCritical(ex, "{ErrorMessage}{Message}", ErrorMessage, ex.Message);
            }
            return response.IsSuccess(succes: response.Success = true);
        }

        public async Task<BaseResponse> ReactiveAsync(Guid id)
        {
            var response = new BaseResponse();
            try
            {
                var practitioner = await FindByIdAsync(id);
                if (!practitioner.Success)
                {
                    throw new InvalidOperationException($"The practitioner with the id: {id} was not found");
                }
                await _practitionerUnitOfWork.PractitionerRepository.Reactive(id);
                await _practitionerUnitOfWork.CommitAsync();
                response.Success = true;


            }
            catch (Exception ex)
            {

                //response.ErrorMessage = "An error ocurred while trying to reactive the practitioner";
                //_logger.LogCritical(ex, "{ErrorMessage}{Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse> UpdateAsync(Guid id, PractitionerDtoRequest practitionerResources)
        {
            var response = new BaseResponse();
            try
            {
                var practitioner = await _practitionerUnitOfWork.PractitionerRepository.FindByIdAsync(id);
                if (practitioner is null)
                {
                    return response.Failure(errorMessage:PractitionerErrors.NotFound(id));
                }
                var practitionerUpdated = _mapper.Map(practitionerResources, practitioner);
                _practitionerUnitOfWork.PractitionerRepository.Update(practitionerUpdated);
                await _practitionerUnitOfWork.CommitAsync();
                response.IsSuccess(succes: response.Success = true);

            }
            catch (Exception ex)
            {

                string ErrorMessage = "An error ocurred while trying to reactive the practitioner";
                _logger.LogCritical(ex, "{ErrorMessage}{Message}", ErrorMessage, ex.Message);
            }
            return response;
        }
    }
}

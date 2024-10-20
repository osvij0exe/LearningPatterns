using AutoMapper;
using Consultorio.Entities;
using Consultorio.Models.Helpers;
using Consultorio.Models.Request;
using Consultorio.Models.Responses;
using Consultorio.Repository.Errors;
using Consultorio.Repository.UnitOfWork.Implementation;
using Consultorio.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Services.Implementation
{
    public class PatientServices : IPatientServices
    {
        private readonly PatientUnitOfWork _patientUnitOfWork;
        private readonly ILogger<PatientServices> _logger;
        private readonly IMapper _mapper;

        public PatientServices(PatientUnitOfWork patientUnitOfWork,
            ILogger<PatientServices> logger,
            IMapper mapper)
        {
            _patientUnitOfWork = patientUnitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BaseResponseGeneric<Guid>> AddAsync(PatientDtoRequest patientRequest)
        {
            var response = new BaseResponseGeneric<Guid>();

            try
            {
                var patient = _mapper.Map<Patient>(patientRequest);
                _patientUnitOfWork.PatientRepository.Add(patient);
                await _patientUnitOfWork.CommitAsync();
                response.IsSucess(
                    sucess: response.Success = true,
                    data: response.Data = patient.Id);

            }
            catch (Exception ex)
            {

                string erroMessage = "An error ocurred while trying to add te patient";
                _logger.LogCritical(ex, "{ErrorMessage}{Message}", erroMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse> DeleteAsync(Guid id)
        {
            var response = new BaseResponse();

            try
            {
                var patient = await FindByIdAsNoTrackingAsync(id);

                if(!patient.Success)
                {
                    return response.Failure(PatientErrors.NotFound(id));
                }

                _patientUnitOfWork.PatientRepository.Delete(_mapper.Map<Patient>(patient.Data));
                await _patientUnitOfWork.CommitAsync();
                response.IsSuccess(succes: response.Success = true);

            }
            catch (Exception ex)
            {

                string ErrorMessage = "An erro ocurred while trying to delete the patient";
                _logger.LogCritical(ex, "{ErrorMessage}{Message}", ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponseGeneric<PatientDtoResponse>> FindByIdAsNoTrackingAsync(Guid id)
        {
            var response = new BaseResponseGeneric<PatientDtoResponse>();

            try
            {

                var patient = await _patientUnitOfWork.PatientRepository.FindByIdAsNoTrackingAsync(id);
                if (patient is null)
                {
                    return response.Failure(sucess:false,errorMessage: PatientErrors.NotFound(id));
                }
                response.IsSucess(
                    sucess:response.Success = true,
                    data:response.Data = _mapper.Map<PatientDtoResponse>(patient));

            }
            catch (Exception ex)
            {

                string ErrorMessage= "An error ocurred while trying to find the patient";
                _logger.LogCritical(ex, "{ErrorMessage}{Message}", ErrorMessage, ex.Message);
            }
            return response;


        }

        public async Task<BaseResponseGeneric<PatientDtoResponse>> FindByIdAsync(Guid id)
        {
            var resposne = new BaseResponseGeneric<PatientDtoResponse>();
            try
            {
                var patient = await _patientUnitOfWork.PatientRepository.FindByIdAsync(id);
                if(patient is null)
                {
                    return resposne.Failure(sucess: false, PatientErrors.NotFound(id));
                }
                var patientData = _mapper.Map<PatientDtoResponse>(patient);

                resposne.IsSucess(
                    sucess: resposne.Success = true, 
                    data: resposne.Data = patientData);



            }
            catch (Exception ex)
            {

                string ErrorMessage = "An error ocurred while trying to find the patient";
                _logger.LogCritical(ex, "{ErroMessage}{Message}", ErrorMessage, ex.Message);
            }
            return resposne;
        }

        public async Task<CollectionBaseResponseGeneric<PatientDtoResponse>> GetListAsync()
        {
            var response = new CollectionBaseResponseGeneric<PatientDtoResponse>();

            try
            {
                var patientList = await _patientUnitOfWork.PatientRepository.ListAsync();
                response.ISuccess(
                    sucess: response.Success = true, 
                    data: response.Data = _mapper.Map<ICollection<PatientDtoResponse>>(patientList));


            }
            catch (Exception ex)
            {

                string ErrorMessage = "An error oucrred while trying to list patinets";
                _logger.LogCritical(ex, "{ErrorMessage}{Message}", ErrorMessage, ex.Message);
            }
            return response;

        }

        public async Task<BaseResponse> LogicDeleteAsync(Guid id)
        {
            var response = new BaseResponse();
            try
            {

                var patient = await FindByIdAsync(id);
                if (!patient.Success)
                {
                    return response.Failure(PatientErrors.NotFound(id));
                }

                await _patientUnitOfWork.PatientRepository.LogicDelete(id);
                await _patientUnitOfWork.CommitAsync();
                response.IsSuccess(succes: response.Success = true);
            }
            catch (Exception ex)
            {

                string ErrorMessage = "An erro ocurred while trying to delete the patient";
                _logger.LogCritical(ex, "{ErrorMessage}{Message}", ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse> ReactiveAsync(Guid id)
        {
            var response = new BaseResponse();
            try
            {
                var patient = await FindByIdAsync(id);
                if (!patient.Success)
                {
                    return response.Failure(PatientErrors.NotFound(id));
                }

                await _patientUnitOfWork.PatientRepository.Reactive(id);
                await _patientUnitOfWork.CommitAsync();
                response.IsSuccess(succes: response.Success = true);
            }
            catch (Exception ex)
            {

                string ErrorMessage = "An error ocurred while trying to reactive the patient";
                _logger.LogCritical(ex, "{ErrorMessage}{Message}", ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse> UpdateAsync(Guid id, PatientDtoRequest patientResources)
        {
            var response = new BaseResponse();
            try
            {
                var patient = await _patientUnitOfWork.PatientRepository.FindByIdAsync(id);
                if (patient is null)
                {
                    return response.Failure(errorMessage:PatientErrors.NotFound(id));
                }

                var patientUpdated = _mapper.Map(patientResources, patient);
                _patientUnitOfWork.PatientRepository.Update(patientUpdated);
                await _patientUnitOfWork.CommitAsync();
                response.IsSuccess(succes: response.Success = true);
            }
            catch (Exception ex)
            {

                string ErrorMessage = "";
                _logger.LogCritical(ex, "{ErrorMessage}{Message}", ErrorMessage, ex.Message);
            }
            return response;
        }
    }
}

using Lab11.Models.DTOs;

namespace Lab11.Services;

public interface IPatientService
{
    Task<GetPatientInfoDTO?> GetPatientInfo(int id);

}
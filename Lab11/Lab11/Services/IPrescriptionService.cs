using Lab11.Models.DTOs;

namespace Lab11.Services;

public interface IPrescriptionService
{
    Task<string> AddPrescriptionAsync(AddPrescriptionRequestDTO request);
    
}
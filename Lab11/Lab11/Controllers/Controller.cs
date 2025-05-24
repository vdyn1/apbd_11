using Lab11.Models.DTOs;
using Lab11.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab11.Controllers;

[ApiController]
[Route("api/v1/prescriptions")]
public class PrescriptionsController : ControllerBase
{
    private readonly IPrescriptionService _prescriptionService;
    private readonly IPatientService _patientService;

    public PrescriptionsController(IPrescriptionService prescriptionService, IPatientService patientService)
    {
        _prescriptionService = prescriptionService;
        _patientService = patientService;
    }

    
    [HttpPost]
    public async Task<IActionResult> AddPrescription([FromBody] AddPrescriptionRequestDTO request)
    {
        var result = await _prescriptionService.AddPrescriptionAsync(request);

        if (result == "Prescription added successfully.")
            return Ok(new { message = result });

        return BadRequest(new { error = result });
    }

    [HttpGet("patient/{id}")]
    public async Task<IActionResult> GetPatientDetails(int id)
    {
        var result = await _patientService.GetPatientInfo(id);

        if (result == null)
            return NotFound(new { error = $"Patient with ID {id} not found." });

        return Ok(result);
    }
}
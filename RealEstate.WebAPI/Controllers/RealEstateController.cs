using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Core.Services.Helpers.Results;
using RealEstate.Core.Services.Interface;
using RealEstate.DTO;
using RealEstate.DTO.RealEstate;
using System.Net;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "AdminOnly")]
[ProducesResponseType((int)HttpStatusCode.OK)]
[ProducesResponseType((int)HttpStatusCode.BadRequest)]
[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
public class RealEstateController : ControllerBase
{
    private readonly IRealEstateService _realEstateService;

    public RealEstateController(IRealEstateService realEstateService)
    {
        _realEstateService = realEstateService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<RealestateDTO>> GetAllRealEstates()
    {
        var result = _realEstateService.GetAllRealEstates();
        if (result.Any())
        {
            var response = ApiResult<IEnumerable<RealestateDTO>>.WithCode(HttpStatusCode.OK, result);
            return ApiActionResult<IEnumerable<RealestateDTO>>.WithResult(response).Return();
        }
        else
        {
            var response = ApiResult<IEnumerable<RealestateDTO>>.WithBadRequest("Unable to retrieve Leads");
            return ApiActionResult< IEnumerable<RealestateDTO>>.WithResult(response).Return();
        }
    }

    [HttpGet("{id}")]    
    public ActionResult<ResponseDTO<RealestateDTO>> GetRealEstateById(int id)
    {
        var result = _realEstateService.GetRealEstateById(id);
        if (result.Success)
        {
            var response = ApiResult<ResponseDTO<RealestateDTO>>.WithCode(HttpStatusCode.OK, result);
            return ApiActionResult<ResponseDTO<RealestateDTO>>.WithResult(response).Return();
        }
        else
        {
            var response = ApiResult<ResponseDTO<RealestateDTO>>.WithBadRequest(result.Message);
            return ApiActionResult<ResponseDTO<RealestateDTO>>.WithResult(response).Return();
        }
    }

    [HttpPost]
    public ActionResult<ResponseDTO<RealestateDTO>> CreateRealEstate([FromBody] CreateRealestateDTO request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = _realEstateService.CreateRealEstate(request);
        if (result.Success)
        {
            var response = ApiResult<ResponseDTO<RealestateDTO>>.WithCode(HttpStatusCode.OK, result);
            return ApiActionResult<ResponseDTO<RealestateDTO>>.WithResult(response).Return();
        }
        else
        {
            var response = ApiResult<ResponseDTO<RealestateDTO>>.WithBadRequest(result.Message);
            return ApiActionResult<ResponseDTO<RealestateDTO>>.WithResult(response).Return();
        }
    }

    [HttpPut("{id}")]
    public ActionResult<ResponseDTO<RealestateDTO>> UpdateRealEstate(int id, [FromBody] UpdateRealestateDTO request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = _realEstateService.UpdateRealEstate(id, request);
        if (result.Success)
        {
            var response = ApiResult<ResponseDTO<RealestateDTO>>.WithCode(HttpStatusCode.OK, result);
            return ApiActionResult<ResponseDTO<RealestateDTO>>.WithResult(response).Return();
        }
        else
        {
            var response = ApiResult<ResponseDTO<RealestateDTO>>.WithBadRequest(result.Message);
            return ApiActionResult<ResponseDTO<RealestateDTO>>.WithResult(response).Return();
        }
    }

    [HttpDelete("{id}")]
    public ActionResult<ResponseDTO<RealestateDTO>> DeleteRealEstate(int id)
    {
        var result = _realEstateService.DeleteRealEstate(id);
        if (result.Success)
        {
            var response = ApiResult<ResponseDTO<RealestateDTO>>.WithCode(HttpStatusCode.OK, result);
            return ApiActionResult<ResponseDTO<RealestateDTO>>.WithResult(response).Return();
        }
        else
        {
            var response = ApiResult<ResponseDTO<RealestateDTO>>.WithBadRequest(result.Message);
            return ApiActionResult<ResponseDTO<RealestateDTO>>.WithResult(response).Return();
        }
    }
}
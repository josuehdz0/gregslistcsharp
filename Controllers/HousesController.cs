using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace gregslistcsharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HousesController : ControllerBase
{
  private readonly HousesService housesService;

  public HousesController(HousesService housesService)
  {
    this.housesService = housesService;
  }

  [HttpGet]
  public ActionResult<List<House>> Find()
  {
    try
    {
      List<House> houses = housesService.Find();
      return Ok(houses);
    }
    catch (System.Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]

  public ActionResult<House> Find(int id)
  {
    try
    {
      House house = housesService.Find(id);
      return Ok(house);
    }
    catch (System.Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}

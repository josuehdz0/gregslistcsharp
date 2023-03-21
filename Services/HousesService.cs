using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gregslistcsharp.Services;

public class HousesService
{
  private readonly HousesRepository _repo;

  public HousesService(HousesRepository repo)
  {
    _repo = repo;
  }

  internal List<House> Find()
  {
    List<House> houses = _repo.FindAll();
    return houses;
  }

  internal House Find(int id)
  {
    House house = _repo.FindOne(id);
    if (house == null) throw new Exception($"no house with id: {id}");
    return house;
  }
}

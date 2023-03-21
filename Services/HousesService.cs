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

  internal House Create(House houseData)
  {
    House house = _repo.Create(houseData);
    return house;
  }

  internal House Find(int id)
  {
    House house = _repo.FindOne(id);
    if (house == null) throw new Exception($"no house with id: {id}");
    return house;
  }

  internal string Remove(int id)
  {
    House house = this.Find(id);
    bool result = _repo.Remove(id);
    if (!result) throw new Exception($"Something went wrong when trying to delete house with id {house.Id}");
    return $"deleted {house.Id}";
  }
}

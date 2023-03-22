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

  internal House Update(House updateData)
  {
    House original = this.Find(updateData.Id);
    original.Rooms = updateData.Rooms != 0 ? updateData.Rooms : original.Rooms;
    original.Bathrooms = updateData.Bathrooms != 0 ? updateData.Bathrooms : original.Bathrooms;
    original.Year = updateData.Year != 0 ? updateData.Year : original.Year;
    original.Price = updateData.Price != 0 ? updateData.Price : original.Price;
    original.imgUrl = updateData.imgUrl != null ? updateData.imgUrl : original.imgUrl;
    original.Description = updateData.Description != null ? updateData.Description : original.Description;
    int rowsAffected = _repo.Update(original);
    if (rowsAffected == 0) throw new Exception($"could not modify {updateData.Rooms} {updateData.Bathrooms} @ id {updateData.Id} for some reason.");
    if (rowsAffected > 1) throw new Exception($"Something horrible just happend, you made at least {rowsAffected} of houses into {updateData.Rooms} {updateData.Bathrooms}, might wanna check the db");
    return original;
  }
}

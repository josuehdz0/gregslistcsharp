using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gregslistcsharp.Repositories;

public class HousesRepository
{
  private readonly IDbConnection _db;

  public HousesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal List<House> FindAll()
  {
    string sql = @"
    SELECT
    *
    FROM houses;
    ";
    List<House> houses = _db.Query<House>(sql).ToList();
    return houses;
  }

  internal House FindOne(int id)
  {
    string sql = @"
    SELECT
    *
    FROM houses
    WHERE id = @id;
    ";
    House house = _db.Query<House>(sql, new { id }).FirstOrDefault();
    return house;
  }
}

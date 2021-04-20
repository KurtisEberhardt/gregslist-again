using System;
using System.Collections.Generic;
using System.Data;
using gregslist_again.Models;
using Dapper;


namespace gregslist_again.repos
{
    public class HouseRepo
    {
        public readonly IDbConnection _db;

        public HouseRepo(IDbConnection db)
        {
            _db = db;
        }
        internal IEnumerable<House> Get()
        {
            string sql = "SELECT * FROM houses;";
            return _db.Query<House>(sql);
        }
        internal House Get(int id)
        {
            string sql = "SELECT * FROM houses WHERE id=@id;";
            return _db.QueryFirstOrDefault<House>(sql, new { id });
        }
        internal House Create(House newHouse)
        {
            string sql = @"
            INSERT INTO houses
            (bedrooms, bathrooms, floors, sqFoot, yearBuilt, price, address)
            VALUES
            (@bedrooms, @bathrooms, @floors, @sqFoot, @yearBuilt, @price, @address)
            ";
            int id = _db.ExecuteScalar<int>(sql, newHouse);
            newHouse.Id = id;
            return newHouse;
        }
        internal House Edit(House original)
        {
            string sql = @"
            UPDATE houses
            SET
                bedrooms = @bedrooms,
                bathrooms = @bathrooms,
                floors = @floors,
                sqFoot = @sqFoot,
                yearBuilt = @yearBuilt,
                price = @price,
                address = @address
            WHERE id = @id
            SELECT * FROM houses WHERE id=@id;";
            return _db.QueryFirstOrDefault<House>(sql, original);
        }
        internal void Delete(int id)
        {
            string sql = "DELETE FROM houses WHERE id=@id;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}
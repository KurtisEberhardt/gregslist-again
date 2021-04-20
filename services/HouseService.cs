using System;
using System.Collections.Generic;
using gregslist_again.Models;
using gregslist_again.repos;

namespace gregslist_again.services
{
    public class HouseService
    {
        private readonly HouseRepo _repo;
        public HouseService(HouseRepo repo)
        {
            _repo = repo;
        }
        internal IEnumerable<House> Get()
        {
            return _repo.Get();
        }
        internal House Get(int id)
        {
            House house = _repo.Get(id);
            if (house == null)
            {
                throw new Exception("wrong id, dummy.");
            }
            return house;
        }
        internal House Create(House newHouse)
        {
            return _repo.Create(newHouse);
        }
        internal House Edit(House editHouse)
        {
            House original = Get(editHouse.Id);
            return _repo.Edit(original);

        }
        internal House Delete(int id)
        {
            House original = Get(id);
            _repo.Delete(id);
            return original;

        }

    }
}
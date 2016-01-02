using Repositories;
using Repositories.LinqToSqlData;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

namespace WebAPi
{
    public class NutritionTrackerController : ApiController
    {
        protected readonly IRepository<FoodDescrption> _FoodDescrptionRepo;

        public NutritionTrackerController(
            IRepository<FoodDescrption> foodDescrptionRepo)
        {
            if (foodDescrptionRepo == null)
                throw new ArgumentNullException("foodDescrptionRepo");

            _FoodDescrptionRepo = foodDescrptionRepo;
        }

        [ActionName("foods")]
        public IList<FoodDescrption> GetFoods(string value, 
            int pageNumber, 
            int pageSize = 20)
        {
            return _FoodDescrptionRepo.Find(
                f => f.Long_Desc.StartsWith(value), 
                ((pageNumber - 1) * pageSize),
                pageSize,
                f => f.Long_Desc, false);
        }
    }
}

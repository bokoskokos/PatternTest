using System;
using System.Collections.Generic;

namespace MyPegasus.Web.Mappers
{
    public class PegasusMapper : IPegasusMapper
    {
        public TTo Map<TFrom, TTo>(TFrom @from)
        {
            try
            {
                var mapper = AutoMapper.Mapper.Map<TFrom, TTo>(from);
                return mapper;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to mapp {typeof(TFrom)} to {typeof(TTo)}. Are you missing a mapping configuration?", ex);
            }
        }

        public IEnumerable<TTo> Map<TFrom, TTo>(IEnumerable<TFrom> @from)
        {
            return Map<IEnumerable<TFrom>, IEnumerable<TTo>>(@from);
        }
    }
}
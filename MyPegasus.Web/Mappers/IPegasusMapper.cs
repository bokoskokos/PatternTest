using System.Collections.Generic;

namespace MyPegasus.Web.Mappers
{
    public interface IPegasusMapper
    {
        TTo Map<TFrom, TTo>(TFrom from);
        IEnumerable<TTo> Map<TFrom, TTo>(IEnumerable<TFrom> from);
    }
}
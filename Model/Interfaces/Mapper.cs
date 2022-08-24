using System;
using System.Collections.Generic;
using System.Data;

namespace Model.Interfaces
{
    public interface Mapper
    {
        dynamic MapEntityToData(IDataRecord record);
        List<Object> MapEntityToData(DataTable table);
        dynamic MapEntityToDTO();
    }
}

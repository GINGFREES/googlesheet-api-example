using System;
namespace google_sheet_api_service.Models.Utils
{
    public interface ModelBase<T>
    {
        T GetModel(int index, IList<Object> row);
    }
}
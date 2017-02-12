#r "Microsoft.WindowsAzure.Storage"
using Microsoft.WindowsAzure.Storage.Table;
using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, CloudTable outputTable, TraceWriter log)
{
    string id = req.GetQueryNameValuePairs()
        .First(q => string.Compare(q.Key, "id", true) == 0)
        .Value;

    var item = new TableEntity(id, id)
    {
        ETag = "*"
    };
    var operation = TableOperation.Delete(item);
    await outputTable.ExecuteAsync(operation);
    
    return req.CreateResponse(HttpStatusCode.NoContent);
}

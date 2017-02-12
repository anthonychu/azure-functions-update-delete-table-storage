#r "Microsoft.WindowsAzure.Storage"
using Microsoft.WindowsAzure.Storage.Table;
using System.Net;

public static async Task<HttpResponseMessage> Run(Item item, CloudTable outputTable, TraceWriter log)
{
    item.PartitionKey = item.id;
    item.RowKey = item.id;
    item.ETag = "*";

    var operation = TableOperation.Replace(item);
    await outputTable.ExecuteAsync(operation);

    return new HttpResponseMessage(HttpStatusCode.NoContent);
}

public class Item: TableEntity
{
    public string id { get; set; }
    public string value { get; set; }
}

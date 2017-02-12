let azure = require('azure-storage');

module.exports = function (context, req) {
    let item = req.body;
    item.PartitionKey = item.id;
    item.RowKey = item.id;
    
    let connectionString = process.env.StorageConnectionString;
    let tableService = azure.createTableService(connectionString);
    tableService.replaceEntity('items', item, (error, result, response) => {
        let res = {
            statusCode: error ? 400 : 204,
            body: null
        };
        context.done(null, res);
    });
};

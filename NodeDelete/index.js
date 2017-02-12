let azure = require('azure-storage');

module.exports = function (context, req) {
    let id = req.query.id;

    let connectionString = process.env.StorageConnectionString;
    let tableService = azure.createTableService(connectionString);

    let item = {
        PartitionKey: id,
        RowKey: id
    };

    tableService.deleteEntity('items', item, (error, response) => {
        let res = {
            statusCode: error ? 400 : 204,
            body: null
        };
        context.done(null, res);
    });
};

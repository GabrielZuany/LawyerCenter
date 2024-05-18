import { MongoClient } from 'mongodb';

const express = require('express');
const body = require('body-parser');
const HOST = 'localhost';
const DB = 'test';

async function start() {
    try {
        const app = express();
        const mongo = new MongoClient('mongodb://'+HOST+':27017');
        await mongo.connect();

        app.db = mongo.db(DB);

        // body-parser. Limit the size of the request body to 500kb
        app.use(body.json(
            {
                limit: '500kb'
            }
        ));

        // Routes
        app.use('/client', require('./routes/client'));

        // Start the server
        app.listen(3000, () => {
            console.log('Server is running on port 3000');
        });
    } 
    catch (error) {
        console.log(error);
    }
}

start();
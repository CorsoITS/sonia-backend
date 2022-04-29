require('dotenv').config();
const express = require('express');
const { json, urlencoded } = require('body-parser');
const cors = require('cors');
const { ConnectRouter } = require('./routes/main-router');
const app = express();
const port = 3000;

app.use(json());
app.use(cors());
app.use(urlencoded({ extended: true }));

app.options('*', cors());

app.get('/test', (req, res) => {
    res.json ({
        messaggio: 'everything ok'
    }).send();
});

ConnectRouter(app);

app.listen(port);
require('dotenv').config();
const express = require('express');
const { json, urlencoded } = require('body-parser');
const { routerPersona } = require('./routers/persona');
const { routerPrenotazione } = require('./routers/prenotazione');
const { routerPrenotazionePersona } = require('./routers/prenotazione-persona');
const fileUpload = require('express-fileupload');
const app = express();
const port = 3000;

app.use(express.static());
app.use(json());

app.get('/test', (req, res) => {
    res.json ({
        messaggio: 'everything ok'
    }).send();
});

app.listen(port);
const { routerOperatore } = require("./operatore-router");
const { routerPersona } = require("./persona-router");
const { routerPrenotazione } = require("./prenotazione-router");
const { routerSede } = require("./sede-router");

function ConnectRouter (app) {
    app.use('/operatore', routerOperatore);
    app.use('/persona', routerPersona);
    app.use('/sede', routerSede);
    app.use('/prenotazione', routerPrenotazione);
}

module.exports = {
    ConnectRouter
};
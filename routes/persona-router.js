const Router = require('express');
const { PersonaController } = require('../controllers/PersonaController');
const routerPersona = Router();

// console.log('trying operatore router...')
routerPersona.get('/', PersonaController.lista);
routerPersona.post('/', PersonaController.insert);

module.exports = {
    routerPersona
}
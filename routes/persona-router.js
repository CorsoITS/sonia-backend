const Router = require('express');
const { PersonaController } = require('../controllers/PersonaController');
const routerPersona = Router();

// console.log('trying operatore router...')
routerPersona.get('/', PersonaController.lista);
routerPersona.get('/:id', PersonaController.get);
routerPersona.post('/', PersonaController.insert);
routerPersona.put('/:id', PersonaController.update);

module.exports = {
    routerPersona
}
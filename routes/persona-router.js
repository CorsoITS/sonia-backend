const Router = require('express');
const { PersonaController } = require('../controllers/PersonaController');
const { checkId } = require('../middlewares/check-id');
const routerPersona = Router();

// console.log('trying operatore router...')
routerPersona.get('/', PersonaController.lista);
routerPersona.get('/:id', checkId, PersonaController.get);
routerPersona.post('/', PersonaController.insert);
routerPersona.put('/:id', checkId, PersonaController.update);
routerPersona.delete('/:id', checkId, PersonaController.delete);

module.exports = {
    routerPersona
}
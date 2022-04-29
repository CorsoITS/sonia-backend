const Router = require('express');
const { PersonaController } = require('../controllers/PersonaController');
const { checkIdPersona } = require('../middlewares/check-id');
const routerPersona = Router();

// console.log('trying operatore router...')
routerPersona.get('/', PersonaController.lista);
routerPersona.get('/:id', checkIdPersona, PersonaController.get);
routerPersona.post('/', PersonaController.insert);
routerPersona.put('/:id', checkIdPersona, PersonaController.update);
routerPersona.delete('/:id', checkIdPersona, PersonaController.delete);

module.exports = {
    routerPersona
}
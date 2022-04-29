const Router = require('express');
const { PrenotazioneController } = require('../controllers/PrenotazioneController');
const { checkIdPrenotazione } = require('../middlewares/check-id');
const routerPrenotazione = Router();

// console.log('trying operatore router...')
routerPrenotazione.get('/', PrenotazioneController.lista);
routerPrenotazione.get('/:id', checkIdPrenotazione, PrenotazioneController.get);
routerPrenotazione.post('/', PrenotazioneController.insert);
routerPrenotazione.put('/:id', checkIdPrenotazione, PrenotazioneController.update);
routerPrenotazione.delete('/:id', checkIdPrenotazione, PrenotazioneController.delete);

module.exports = {
    routerPrenotazione
}
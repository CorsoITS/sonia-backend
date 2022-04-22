const { Persona } = require("../model/models/Persona");

class PersonaController {
    static async lista (req, res) {
        // console.log('trying operatore controller...')
        if (req.query.q) {
            if (!req.params) req.params = {};
            req.params.id = req.query.q;
            return PersonaController.length(req, res);
        }

        let result = await Persona.lista();
        return res.json(result);
    }

    static async get (req, res) {
        let result = await Persona.get(req.params.id);
        return res.json(result);
    }

    static async insert (req, res) {
        let np = new Persona();
        if (req.body.nome) np.setNome(req.body.nome);
        if (req.body.cognome) np.setCognome(req.body.cognome);
        if (req.body.codice_fiscale) np.setCodFis(req.body.codice_fiscale);
        await np.insert();
        return res.json({
            message: 'done'
        }); 
    }

    static async update (req, res) {
        let np = await Persona.get(req.params.id);
        if (req.body.nome) np.setNome(req.body.nome);
        if (req.body.cognome) np.setCognome(req.body.cognome);
        if (req.body.codice_fiscale) np.setCodFis(req.body.codice_fiscale);
        await np.update();
        return res.json({
            message: 'done'
        }); 
    }
}

module.exports = {
    PersonaController
}
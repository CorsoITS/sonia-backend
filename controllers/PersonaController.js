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
}

module.exports = {
    PersonaController
}
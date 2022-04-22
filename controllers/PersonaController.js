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
        let result;
        if (! req.Persona) {
            result = await Persona.get(req.params.id);
        } else {
            result = req.Persona;
        }
        return res.json(result);
    }

    static async insert (req, res) {
        try {
            let np = new Persona();
            if (req.body.nome) np.setNome(req.body.nome);
            if (req.body.cognome) np.setCognome(req.body.cognome);
            if (req.body.codice_fiscale) np.setCodFis(req.body.codice_fiscale);
            await np.save();
            // return res.json({
            //     message: 'done'
            // }); 
            res.status(200).send("Ok");
        } catch {
            res.status(500).send ("Internal Server Error");
        }
    }

    static async update (req, res) {
        try {
            let np = await Persona.get(req.params.id);
            if (req.body.nome) np.setNome(req.body.nome);
            if (req.body.cognome) np.setCognome(req.body.cognome);
            if (req.body.codice_fiscale) np.setCodFis(req.body.codice_fiscale);
            await np.save();
            // return res.json({
            //     message: 'done'
            // }); 
            res.status(200).send("Ok");
        } catch {
            res.status(500).send ("Internal Server Error");
        }
    }

    static async delete (req, res) {
        try {
            if (await Persona.delete(req.params.id)) {
                res.status(200).send('ok');
            } else {
                res.status(400).send ("something went wrong");
            }
        // return res.json({
        //     message: 'successfully deleted'
        // }); 
        } catch {
            res.status(500).send ("Internal Server Error");
        }
    }
}

module.exports = {
    PersonaController
}
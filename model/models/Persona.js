const { listPersona } = require("../dao/persona.dao");

class Persona {
    constructor(p) {
        if (p) {
            if (p.id) this.id = p.id;
            if (p.nome) this.nome = p.nome;
            if (p.cognome) this.cognome = p.cognome;
            if (p.codice_fiscale) this.codice_fiscale  = p.codice_fiscale;
        }
    }

    static async lista () {
        let listPersonaDAO = await listPersona();
        let res = [];
        listPersonaDAO.forEach(element => {
            res.push(new Persona(element));
        });
        return res;
    }
}

module.exports = {
    Persona
}
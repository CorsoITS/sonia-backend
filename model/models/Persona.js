const { listPersona, insertPersona } = require("../dao/persona.dao");

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

    setId(x) {
    if (x == null || typeof(x) == 'undefined')  throw 'Nome cannot be null';
    this.id = x;
    }
    getId() {
        return this.id;
    }

    setNome(x) {
        if (x == null || typeof(x) == 'undefined')  throw 'Nome cannot be null';
        this.nome = x;
    }
    getNome() {
        return this.nome;
    }

    setCognome(x) {
        if (x == null || typeof(x) == 'undefined')  throw 'Cognome cannot be null';
        this.cognome = x;
    }
    getCognome() {
        return this.cognome;
    }

    setCodFis(x) {
        this.codice_fiscale = x;

    }
    getCodFis() {
        return this.codice_fiscale;
    }

    async save () {
        let res = await insertPersona (this.nome, this.cognome, this.codice_fiscale);
        this.setId(res);
        if (! res) throw 'save Persona failed (insert case).'; 
    }
}

module.exports = {
    Persona
}
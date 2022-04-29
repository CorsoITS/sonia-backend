const { listOperatore, insertOperatore, updateOperatore, getOperatoreById, deleteOperatore } = require("../dao/operatore.dao");


class Operatore {
    constructor(o) {
        if (o) {
            if (o.id) this.id = o.id;
            if (o.ruolo) this.ruolo = o.ruolo;
            if (o.nome) this.nome = o.nome;
            if (o.cognome) this.cognome = o.cognome;
            if (o.username) this.username = o.username;
            if (o.password) this.password  = o.password;

            if (o.sede_id) this.sede_id = o.sede_id;
            if (o.nome) this.nome = o.nome;
            if (o.citta) this.citta = o.citta;
            if (o.indirizzo) this.indirizzo  = o.indirizzo;
        }
    }

    static async lista () {
        let listOperatoreDAO = await listOperatore();
        let res = [];
        listOperatoreDAO.forEach(element => {
            res.push(new Operatore(element));
        });
        return res;
    }

    static async get(id) {
        let pf = await getOperatoreById(id);
        if (pf) { return new Operatore(pf);}
        return null;
    }

    static async delete(id) {
        return await deleteOperatore(id);
    }

    setId(x) {
        if (x == null || typeof(x) == 'undefined')  throw 'Nome cannot be null';
        this.id = x;
    }
    getId() {
            return this.id;
    }

    setRuolo(x) {
        if (x == null || typeof(x) == 'undefined')  throw 'Nome cannot be null';
        this.ruolo = x;
    }
    getRuolo() {
            return this.ruolo;
    }
    
    setNome(x) {
        if (x == null || typeof(x) == 'undefined')  throw 'Nome cannot be null';
        this.nome = x;
    }
    getNome() {
            return this.nome;
    }
    
    setCognome(x) {
        if (x == null || typeof(x) == 'undefined')  throw 'Nome cannot be null';
        this.cognome = x;
    }
    getCognome() {
        return this.cognome;
    }
    
    setUsername(x) {
        if (x == null || typeof(x) == 'undefined')  throw 'Nome cannot be null';
        this.username = x;
    }
    getUsername() {
        return this.username;
    }
    
    setPassword(x) {
        if (x == null || typeof(x) == 'undefined')  throw 'Nome cannot be null';
        this.password = x;
    }
    getPassword() {
        return this.password;
    }
    
    setSedeId(x) {
        if (x == null || typeof(x) == 'undefined')  throw 'Nome cannot be null';
        this.sede_id = x;
    }
    getSedeId() {
        return this.sede_id;
    }
    
    setCitta(x) {
        if (x == null || typeof(x) == 'undefined')  throw 'Citta cannot be null';
        this.citta = x;
    }
    getCitta() {
        return this.citta;
    }
    
    setIndirizzo(x) {
        this.indirizzo = x;
    
    }
    getIndirizzo() {
        return this.indirizzo;
    }
    
    async save () {
            if (typeof (this.id) != 'undefined' && this.id != null ) {
                let res = await updateOperatore (this.id, this.ruolo, this.nome, this.cognome, this.username, this.password, this.sede_id);
                // console.log(res);
                if (! res) throw 'save Operatore failed (insert case).'; 
            } else {
                let res = await insertOperatore (this.ruolo, this.nome, this.cognome, this.username, this.password, this.sede_id);
                this.setId(res);
                if (! res) throw 'save Operatore failed (insert case).'; 
        }
    }
}

module.exports = {
    Operatore
}
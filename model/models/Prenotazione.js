const { listPrenotazione, insertPrenotazione, getPrenotazioneById, updatePrenotazione, deletePrenotazione } = require("../dao/prenotazione.dao");

class Prenotazione {
    constructor(p) {
        if (p) {
            if (p.id) this.id = p.id;
            if (p.data) this.data = p.data;

            if (p.pers_id)                this.pers_id  =p.pers_id;
            if (p.nome)                   this.nome  =p.nome;
            if (p.cognome)                this.cognome=p.cognome;
            if (p.codice_fiscale)         this.codice_fiscale =p.codice_fiscale;

            if (p.sede_id) this.sede_id = p.sede_id;
            if (p.nome) this.nome = p.nome;
            if (p.citta) this.citta = p.citta;
            if (p.indirizzo) this.indirizzo  = p.indirizzo;
        }
    }

    static async lista () {
        let listPrenotazioneDAO = await listPrenotazione();
        let res = [];
        listPrenotazioneDAO.forEach(element => {
            res.push(new Prenotazione(element));
        });
        return res;
    }

    static async get(id) {
        let pf = await getPrenotazioneById(id);
        if (pf) { return new Prenotazione(pf);}
        return null;
    }

    static async delete(id) {
        return await deletePrenotazione(id);
    }

    setId(x) {
    if (x == null || typeof(x) == 'undefined')  throw 'Nome cannot be null';
    this.id = x;
    }
    getId() {
        return this.id;
    }

    setData(x) {
    if (x == null || typeof(x) == 'undefined')  throw 'Nome cannot be null';
    this.data = x;
    }
    getData() {
        return this.data;
    }

    setPersId(x) {
    if (x == null || typeof(x) == 'undefined')  throw 'Nome cannot be null';
    this.pers_id = x;
    }
    getPersId() {
        return this.pers_id;
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

    setCodFis(x) {
        if (x == null || typeof(x) == 'undefined')  throw 'Nome cannot be null';
        this.codice_fiscale = x;
    }
    getCodFis() {
        return this.codice_fiscale;
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
                let res = await updatePrenotazione (this.id, this.data, this.pers_id, this.sede_id);
                // console.log(res);
                if (! res) throw 'save Prenotazione failed (insert case).'; 
            } else {
                let res = await insertPrenotazione (this.data, this.pers_id, this.sede_id);
                this.setId(res);
                if (! res) throw 'save Prenotazione failed (insert case).'; 
        }
    }
}

module.exports = {
    Prenotazione
}
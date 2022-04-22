const { getConnection } = require("../../db/connection")

const listPersona = async () => {
    const conn = await getConnection();
    // console.log('trying operatore');
    const query = 'SELECT * FROM persona';
    const [rows] = await conn.query(query);
    return rows;
}

const insertPersona = async (nome, cognome, codice_fiscale) => {
    const conn = await getConnection();
    const query = 'INSERT INTO persona (nome, cognome, codice_fiscale) VALUES (?, ?, ?)';
    const [res] = await conn.query(query, [nome, cognome, codice_fiscale]);
    return res.insertId;
}

module.exports = {
    listPersona,
    insertPersona
}
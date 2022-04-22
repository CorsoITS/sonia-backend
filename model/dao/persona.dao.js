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

const updatePersona = async (id, nome, cognome, codice_fiscale) => {
    const conn = await getConnection();
    const query = 'UPDATE persona SET nome = ?, cognome = ?, codice_fiscale = ? WHERE id = ?';
    const [res] = await conn.query(query, [nome, cognome, codice_fiscale, id]);
    return res.affectedRows === 1;
}

const getPersonaById = async (id) => {
    const conn = await getConnection();
    const query = 'SELECT * FROM persona WHERE id = ?';
    const [rows] = await conn.query(query, [id]);
    return rows[0];
  }

module.exports = {
    listPersona,
    insertPersona,
    getPersonaById,
    updatePersona
}
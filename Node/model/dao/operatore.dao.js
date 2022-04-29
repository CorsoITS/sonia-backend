const { getConnection } = require("../../db/connection")


const listOperatore = async () => {
    const conn = await getConnection();
    // console.log('trying operatore');
    const query = `SELECT operatore.*, 
    sede.id as sede_id, sede.citta , sede.indirizzo
    FROM operatore  
    LEFT JOIN sede ON operatore.sede_id = sede.id
`;
    const [rows] = await conn.query(query);
    return rows;
}

const insertOperatore = async (ruolo, nome, cognome, username, password, sede_id) => {
    const conn = await getConnection();
    const query = 'INSERT INTO operatore (ruolo, nome, cognome, username, password, sede_id) VALUES (?, ?, ?, ?, ?, ?)';
    const [res] = await conn.query(query, [ruolo, nome, cognome, username, password, sede_id]);
    return res.insertId;
}

const updateOperatore = async (id, ruolo, nome, cognome, username, passwor,sede_id) => {
    const conn = await getConnection();
    const query = 'UPDATE operatore SET ruolo = ?, nome = ?, cognome = ?, username = ?, password = ?, sede_id = ? WHERE id = ?';
    const [res] = await conn.query(query, [ruolo, nome, cognome, username, password, sede_id, id]);
    // console.log(res);
    return res.affectedRows === 1;
}

const getOperatoreById = async (id) => {
    const conn = await getConnection();
    const query = `SELECT operatore.*, 
    sede.id as sede_id, sede.citta , sede.indirizzo
    FROM operatore  
    LEFT JOIN sede ON operatore.sede_id = sede.id
    WHERE operatore.id = ?`;
    const [rows] = await conn.query(query, [id]);
    return rows[0];
  }

const deleteOperatore = async (id) => {
    const conn = await getConnection();
    const query = 'DELETE FROM operatore WHERE id = ?';
    const [res] = await conn.query(query, [id]);
    return res.affectedRows === 1;
  }

module.exports = {
    listOperatore,
    insertOperatore,
    updateOperatore,
    getOperatoreById,
    deleteOperatore
}
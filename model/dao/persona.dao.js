const { getConnection } = require("../../db/connection")

const listPersona = async () => {
    const conn = await getConnection();
    // console.log('trying operatore');
    const query = 'SELECT * FROM persona';
    const [rows] = await conn.query(query);
    return rows;
}

module.exports = {
    listPersona
}
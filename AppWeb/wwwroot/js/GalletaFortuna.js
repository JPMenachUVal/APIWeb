//INICIO CONEXION
const express = require('express');
const mongoose = require('mongoose');

const app = express();
const PORT = process.env.PORT || 3000;

// Conexión a MongoDB 
mongoose.connect('mongodb://localhost:27017/fortunecookie', { useNewUrlParser: true, useUnifiedTopology: true });
const db = mongoose.connection;

// Definición del esquema de la base de datos
const clickSchema = new mongoose.Schema({
    clicks: Number,
    timestamp: { type: Date, default: Date.now },
    ipAddress: String,
});

const Click = mongoose.model('Click', clickSchema);

// Middleware OBTIENE el conteo de clics y la información
app.use('/click-fortune-cookie', async (req, res) => {
    // Obtener la dirección IP del cliente
    const ipAddress = req.headers['x-forwarded-for'] || req.connection.remoteAddress;

    // Crear un nuevo registro en la BD
    const click = new Click({
        clicks: 1,
        ipAddress: ipAddress,
    });

    // Guardar el registro en la BD
    await click.save();

    // Devolver una respuesta
    res.send('Click registrado en la base de datos.');
});

// Iniciar Servidor
app.listen(PORT, () => {
    console.log(`Servidor en ejecución en http://localhost:${PORT}`);
});

///FIN CONEXION

const fortuneCookie = document.getElementById('fortune-cookie');
fortuneCookie.addEventListener('click', async () => {
    openFortuneCookie();
    fortuneCookie.style.transform = 'rotate(180deg)';
    setTimeout(() => {
        fortuneCookie.style.transform = 'rotate(0deg)';
    }, 300);

    // Enviar solicitud al servidor para registrar el clic
    await fetch('http://localhost:3000/click-fortune-cookie');
});





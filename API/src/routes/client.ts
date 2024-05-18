import { createClientController } from '../controllers/createClient';
import { getClientController } from '../controllers/getClient';
import { getClientsController } from '../controllers/getClients';

const express = require('express');
const router = express.Router();

console.log('Clients route loaded');

router.get('/:id', getClientController);
router.get('/', getClientsController);
router.post('/', createClientController);

module.exports = router;
// import NotificationButton from '../NotificationButton';
// import DatePicker from "react-datepicker";

import { useEffect, useState } from 'react';
import 'antd/dist/antd.css'
import './styles.css';
import axios from 'axios';
import { BASE_URL } from '../../utils/request';
import { Filme } from '../../models/filme';
import { Cliente } from '../../models/cliente';

function LocacaoCard() {

    const [filme, setFilmes] = useState<Filme[]>([]);
    const [cliente, setClientes] = useState<Cliente[]>([]);

    useEffect(() => {
        axios.get(`${BASE_URL}/Filme/Consulta`)
            .then(response => {
                setFilmes(response.data);
            })
    }, []);

    useEffect(() => {
        axios.get(`${BASE_URL}/Cliente/Consulta`)
            .then(response => {
                setClientes(response.data);
                console.log(response.data);
            })
    }, []);

    return (
        <>
            <div className="dsmeta-card">
                <h2 className='dsmeta-sales-title'>Filmes</h2>
                <h5 className='dsmeta-sales-description'>Os mais alugados</h5>
                <br />
                <hr className='dsmeta-sales-hr' />
                <div>
                    <table className="dsmeta-sales-table">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Título</th>
                                <th>Classificação</th>
                                <th>Tipo</th>
                            </tr>
                        </thead>
                        <tbody>
                            {filme.map(item => {
                                return (
                                    <tr key={item.filmeId}>
                                        <td>{item.filmeId}</td>
                                        <td>{item.titulo}</td>
                                        <td>{item.classificacao_Indicativa}</td>
                                        <td>{item.lancamento}</td>
                                    </tr>
                                )
                            })}
                        </tbody>
                    </table>
                </div>
            </div>
            <br />
            <div className="dsmeta-card">
                <h2 className='dsmeta-sales-title'>Clientes</h2>
                <h5 className='dsmeta-sales-description'>O segundo que mais alugou filmes</h5>
                <br />
                <hr className='dsmeta-sales-hr' />
                <div>
                    <table className="dsmeta-sales-table">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Nome</th>
                                <th>CPF</th>
                                <th>Data de Nascimento</th>
                            </tr>
                        </thead>
                        <tbody>
                            {cliente.map(item => {
                                return (
                                    <tr key={item.clienteId}>
                                        <td>{item.clienteId}</td>
                                        <td>{item.nome}</td>
                                        <td>{item.cpf}</td>
                                        <td>{item.dataNascimento}</td>
                                    </tr>
                                )
                            })}
                        </tbody>
                    </table>
                </div>
            </div>
        </>
    )
}

export default LocacaoCard

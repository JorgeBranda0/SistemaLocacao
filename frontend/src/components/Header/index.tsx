import logo from '../../assets/img/logo.svg'
import './styles.css';

function Header() {
    return (
        <header>
            <div className="dsmeta-logo-container">
                <img src={logo} alt="DSMeta" />
                <h1 className="dsmeta-titulo">Prime Filmes</h1>
                <p>
                    Desenvolvido por
                    <a href="https://github.com/JorgeBranda0"> @JorgeBranda0</a>
                </p>
            </div>
        </header>
    )
}

export default Header
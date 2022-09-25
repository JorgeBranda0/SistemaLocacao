import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import Header from "./components/Header";
import LocacaoCard from "./components/LocacaoCard/index";

function App() {
  return (
    <>
      <ToastContainer />
      <Header />
      <main>
        <section id="sales">
          <div className="dsmeta-container">
            <LocacaoCard />
          </div>
        </section>
      </main>
    </>
  )
}

export default App

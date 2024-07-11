import React, { useState, useEffect } from "react"
import Pagination from './components/pagination';
import { useNavigate, useParams } from "react-router-dom";
import useAuth from "../../hooks/useAuth";
import * as C from "./components/styles"; // Certifique-se de que os componentes estão exportados corretamente aqui
import random from "../../img/random.png"
import logo from "../../img/logo.png";
import { GlobalStyle } from './components/styles'; // Importe o GlobalStyle aqui
import { RadioButton } from "./components/styles";

const Home = () => {
  const { signout } = useAuth();
  const navigate = useNavigate();
  const [estado, setEstado] = useState("");
  const [tipo, setTipo] = useState("");
  const [currentPage, setCurrentPage] = useState(1);

  const handlePageChange = (pageNumber) => {
    setCurrentPage(pageNumber);
  };

  const handleEstadoChange = (e) => {
    setEstado(e.target.value);
  };
  
  const handleTipoChange = (e) => {
    setTipo(e.target.value);
  };

  const handleLogout = () => {
    signout(); // Isso irá limpar quaisquer tokens de autenticação
    navigate('/signin'); // Isso irá redirecionar o usuário para a tela de login
  };
  
  const photoNull = "https://cloud-object-storage-cos-standard-bucket-1.s3.us-south.cloud-object-storage.appdomain.cloud/random.png";

  var [totalPages, setTotalPages] = useState(0); // Adicione o estado totalPages
  const [id, setId] = useState();
  const [idade, setIdades] = useState([32, 31, 37]);
  const [nome, setNomes] = useState(["Loading...", "Loading...", "Loading..."]);
  const [cidade, setCidades] = useState(["Loading...", "Loading...", "Loading..."]);
  const [uf, setUfs] = useState(["Loading...", "Loading...", "Loading..."]);
  const [descricao, setDescricoes] = useState(["Loading...", "Loading...", "Loading..."]);
  const [photo, setPhoto] = useState(["Loading...", "Loading...", "Loading..."]);

    const fetchPages = async () => {
      const url2 = `http://localhost:5001/api/v1/lawyer/get-all-filtered?category=${tipo}&state=${estado}`;
      try {
        const response2 = await fetch(url2);
        if (!response2.ok) {
          throw new Error('Erro ao obter dados da API');
        }
        const data2 = await response2.json();
        setTotalPages(Math.ceil(data2.length / 3));
        console.log('Total de páginas:', totalPages); // Verifique o valor atribuído
      } catch (error) {
        console.error('Erro na requisição da API:', error);
      }
    };
    
  const fetchLawyers = async () => {
    const skip = (currentPage - 1) * 3;
    const take = 3;
    const url = `http://localhost:5001/api/v1/lawyer/get-filtered?skip=${skip}&take=${take}&category=${tipo}&state=${estado}`;
    const response = await fetch(url);
    if (!response.ok) {
      throw new Error('Network response was not ok');
    }
    const data = await response.json();
    
    console.log('API Response:', data);
    setId(data.map(lawyer => lawyer.id));
    setIdades(data.map(lawyer => lawyer.age));
    setNomes(data.map(lawyer => lawyer.name));
    setCidades(data.map(lawyer => lawyer.city));
    setUfs(data.map(lawyer => lawyer.state));
    setDescricoes(data.map(lawyer => lawyer.description));
    setPhoto(data.map(lawyer => lawyer.photo));
  };
  useEffect(() => {
    fetchLawyers();
    fetchPages();
  }, [estado, tipo, currentPage, totalPages]);

  let { clientId } = useParams();

  const renderProfileCard = (index) => (
    <C.ProfileCard key={index}>
      {(photo[index] == null || photo[index] == "") && <C.ProfileImage src={`${photoNull}`} />}
      {(photo[index] != "") && <C.ProfileImage src={`${photo[index]}`} />}
      <C.ProfileName>
        {nome[index]}
        <C.ProfileDetails>{idade[index]} anos</C.ProfileDetails>
        <C.ProfileDetails>{cidade[index]}, {uf[index]}</C.ProfileDetails>
        <C.Button onClick={() => navigate('/profile/' + id[index])}>Visualizar Perfil</C.Button>
      </C.ProfileName>
      <C.ProfileDescription>{descricao[index]}</C.ProfileDescription>
    </C.ProfileCard>
  );

  const cardVazio = () =>(
    <C.CardVazio></C.CardVazio>
  );

  return (
    <>
      <GlobalStyle />
      <C.LogoutButton onClick={handleLogout}>SAIR</C.LogoutButton>
      <C.logo src = {logo} alt="logo" title="logo"/>
      <C.TopBar />
      
      {/*barra de filtro*/}
      <C.TelaInteira>
        <C.SearchCard>
          <C.SearchFiltro>
            <C.SearchTitle>Estado</C.SearchTitle>
            <C.SearchSelecionavel>
                {/* Adicione estes elementos de seleção para o estado e tipo */}
                <C.Select value={estado} onChange={handleEstadoChange}>
                <option value="">Todos os estados</option>
                <option value="AC">AC</option>
                <option value="AL">AL</option>
                <option value="AP">AP</option>
                <option value="AM">AM</option>
                <option value="BA">BA</option>
                <option value="CE">CE</option>
                <option value="DF">DF</option>
                <option value="ES">ES</option>
                <option value="GO">GO</option>
                <option value="MA">MA</option>
                <option value="MT">MT</option>
                <option value="MS">MS</option>
                <option value="MG">MG</option>
                <option value="PA">PA</option>
                <option value="PB">PB</option>
                <option value="PR">PR</option>
                <option value="PE">PE</option>
                <option value="PI">PI</option>
                <option value="RJ">RJ</option>
                <option value="RN">RN</option>
                <option value="RS">RS</option>
                <option value="RO">RO</option>
                <option value="RR">RR</option>
                <option value="SC">SC</option>
                <option value="SP">SP</option>
                <option value="SE">SE</option>
                <option value="TO">TO</option>
                </C.Select>
              </C.SearchSelecionavel>
              <C.SearchTitle>Tipo</C.SearchTitle>
              <C.SearchSelecionavel>
                <RadioButton>
                  <input type="radio" name="tipo" value="" onChange={handleTipoChange} />
                  Todos os tipos
                  <span className="checkmark"></span>
                </RadioButton>
                <RadioButton>
                  <input type="radio" name="tipo" value="Cível" onChange={handleTipoChange}/>
                  Cível
                  <span className="checkmark"></span>
                </RadioButton>
                <RadioButton>
                  <input type="radio" name="tipo" value="Trabalhista" onChange={handleTipoChange} />
                  Trabalhista
                  <span className="checkmark"></span>
                </RadioButton>
                <RadioButton>
                  <input type="radio" name="tipo" value="Imobiliário" onChange={handleTipoChange} />
                  Imobiliário
                  <span className="checkmark"></span>
                </RadioButton>
                <RadioButton>
                  <input type="radio" name="tipo" value="Ambientalista" onChange={handleTipoChange} />
                  Ambientalista
                  <span className="checkmark"></span>
                </RadioButton>
                <RadioButton>
                  <input type="radio" name="tipo" value="Consumidor" onChange={handleTipoChange} />
                  Consumidor
                  <span className="checkmark"></span>
                </RadioButton>
                <RadioButton>
                  <input type="radio" name="tipo" value="Criminalista" onChange={handleTipoChange} />
                  Criminalista
                  <span className="checkmark"></span>
                </RadioButton>
                <RadioButton>
                  <input type="radio" name="tipo" value="Tributário" onChange={handleTipoChange} />
                  Tributário
                  <span className="checkmark"></span>
                </RadioButton>
                <RadioButton>
                  <input type="radio" name="tipo" value="Previdenciário" onChange={handleTipoChange} />
                  Previdenciário
                  <span className="checkmark"></span>
                </RadioButton>
              </C.SearchSelecionavel>
          </C.SearchFiltro>
        </C.SearchCard>
        <C.Container>
        {!(nome.length >= 1) && cardVazio()}
        {nome.length >= 1 && renderProfileCard(0)}

        {!(nome.length >= 2) && cardVazio()}
        {nome.length >= 2 && renderProfileCard(1)}
        
        {!(nome.length > 2) && cardVazio()}
        {nome.length > 2 && renderProfileCard(2)}
        <Pagination totalPages={totalPages} currentPage={currentPage} onPageChange={handlePageChange}/>
        </C.Container>       
        </C.TelaInteira>
      
    </>
  );
};


export default Home;

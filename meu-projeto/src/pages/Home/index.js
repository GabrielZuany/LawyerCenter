import React, { useState } from "react"
import { useNavigate } from "react-router-dom";
import useAuth from "../../hooks/useAuth";
import * as C from "./styles"; // Certifique-se de que os componentes estão exportados corretamente aqui
import leojardim from "../../img/leojardim.png"; // Corrija os nomes das imagens
import dvd from "../../img/dvd.png";
import maicon from "../../img/maicon.png"
import logo from "../../img/logo.png";
import { GlobalStyle } from './styles'; // Importe o GlobalStyle aqui
import { RadioButton } from "./styles";
import { Link } from 'react-router-dom';
import styled from 'styled-components';

const Home = () => {
  const { signout } = useAuth();
  const navigate = useNavigate();
  const [estado, setEstado] = useState("");
  const [tipo, setTipo] = useState("");

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
  const StyledLink = styled(Link)`
    text-decoration: none; // Remove o sublinhado
  `;
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
                <option value="">Selecione o estado</option>
                <option value="AC">Acre</option>
                <option value="AL">Alagoas</option>
                <option value="AP">Amapá</option>
                <option value="AM">Amazonas</option>
                <option value="BA">Bahia</option>
                <option value="CE">Ceará</option>
                <option value="DF">Distrito Federal</option>
                <option value="ES">Espírito Santo</option>
                <option value="GO">Goiás</option>
                <option value="MA">Maranhão</option>
                <option value="MT">Mato Grosso</option>
                <option value="MS">Mato Grosso do Sul</option>
                <option value="MG">Minas Gerais</option>
                <option value="PA">Pará</option>
                <option value="PB">Paraíba</option>
                <option value="PR">Paraná</option>
                <option value="PE">Pernambuco</option>
                <option value="PI">Piauí</option>
                <option value="RJ">Rio de Janeiro</option>
                <option value="RN">Rio Grande do Norte</option>
                <option value="RS">Rio Grande do Sul</option>
                <option value="RO">Rondônia</option>
                <option value="RR">Roraima</option>
                <option value="SC">Santa Catarina</option>
                <option value="SP">São Paulo</option>
                <option value="SE">Sergipe</option>
                <option value="TO">Tocantins</option>
                </C.Select>
              </C.SearchSelecionavel>
              <C.SearchTitle>Tipo</C.SearchTitle>
              <C.SearchSelecionavel>
                <RadioButton>
                  <input type="radio" name="tipo" value="Cível" onChange={handleTipoChange} />
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
                  <input type="radio" name="tipo" value="Previdenciário" onChange={handleTipoChange} />
                  Previdenciário
                  <span className="checkmark"></span>
                </RadioButton>
              </C.SearchSelecionavel>
          </C.SearchFiltro>
        </C.SearchCard>
        <C.Container>
          {/* Exemplo de perfil para Leo Jardins */}
            <C.ProfileCard>
              <C.ProfileImage src={leojardim} alt="Leo Jardins" />
              <C.ProfileName>
                Leo Jardins
                <C.ProfileDetails>32 anos</C.ProfileDetails>
                <C.ProfileDetails>Vitória, Espírito Santo</C.ProfileDetails>
                <C.Button onClick={() => navigate('/profile')}>Visualizar Perfil</C.Button>
              </C.ProfileName>
              <C.ProfileDescription>
                Descrição breve sobre Leo Jardins ou sua experiência profissional Descrição breve sobre Leo Jardins ou sua experiência profissional Descrição breve sobre Leo Jardins ou sua experiência profissional
              </C.ProfileDescription>
            </C.ProfileCard>
          
          {/* Exemplo de perfil para David Correa */}
          <C.ProfileCard>
              <C.ProfileImage src={dvd} alt="David Correa" />
              <C.ProfileName>
                  David Correa
                <C.ProfileDetails>37 anos</C.ProfileDetails>
                <C.ProfileDetails>Majur, Espírito Santo</C.ProfileDetails>
                {/* MUDAR DEPOIS, ESTA INDO PARA A TELA DO ADVOGADO */}
                <C.Button onClick={() => navigate('/lawyerHome')}>Visualizar Perfil</C.Button>
              </C.ProfileName>
              <C.ProfileDescription>Descrição breve sobre David Correa ou sua experiência profissional.</C.ProfileDescription>
              
          </C.ProfileCard>
          
          {/* Exemplo de perfil para David Correa */}
          <C.ProfileCard>
            <C.ProfileImage src={maicon} alt="Maicon" />
            <C.ProfileName>
              Maicon 
              <C.ProfileDetails>37 anos</C.ProfileDetails>
              <C.ProfileDetails>Jaguare, Espírito Santo</C.ProfileDetails>
              <C.Button onClick={() => navigate('/profile')}>Visualizar Perfil</C.Button>
            </C.ProfileName>
            <C.ProfileDescription>maicon eles nao ligam pra gente</C.ProfileDescription>
          </C.ProfileCard>
          
        </C.Container>
      </C.TelaInteira>
    </>
  );
};

export default Home;

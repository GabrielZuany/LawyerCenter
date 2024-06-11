import React from "react";
import { useNavigate } from "react-router-dom";
import useAuth from "../../hooks/useAuth";
import * as C from "./styles"; // Certifique-se de que os componentes estão exportados corretamente aqui
import leojardim from "../../img/leojardim.png"; // Corrija os nomes das imagens
import dvd from "../../img/dvd.png";
import maicon from "../../img/maicon.png"
import logo from "../../img/logo.png";
import { GlobalStyle } from './styles'; // Importe o GlobalStyle aqui

const Home = () => {
  const { signout } = useAuth();
  const navigate = useNavigate();

  const handleLogout = () => {
    signout(); // Isso irá limpar quaisquer tokens de autenticação
    navigate('/signin'); // Isso irá redirecionar o usuário para a tela de login
  };

  return (
    <>
      <GlobalStyle />
      <C.LogoutButton onClick={handleLogout}>SAIR</C.LogoutButton>
      <C.logo src = {logo} alt="logo" title="logo"/>
      <C.TopBar />
      
      {/*barra de filtro*/}
      <C.TelaInteira>
        <C.SearchCard>
          Filtrar por:
        </C.SearchCard>
        <C.Container>
          {/* Exemplo de perfil para Leo Jardins */}
          <C.ProfileCard>
              <C.ProfileImage src={leojardim} alt="Leo Jardins" />
              <C.ProfileName>
                Leo Jardins
                <C.ProfileDetails>32 anos - Vitória, Espírito Santo</C.ProfileDetails>
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
                <C.ProfileDetails>37 anos - Majur, Espírito Santo</C.ProfileDetails>
              </C.ProfileName>
              <C.ProfileDescription>Descrição breve sobre David Correa ou sua experiência profissional.</C.ProfileDescription>
              
          </C.ProfileCard>
          {/* Exemplo de perfil para David Correa */}
          <C.ProfileCard>
            <C.ProfileImage src={maicon} alt="Maicon" />
            <C.ProfileName>
              Maicon 
              <C.ProfileDetails>37 anos - Jaguare, Espírito Santo</C.ProfileDetails>
            </C.ProfileName>
            <C.ProfileDescription>maicon eles nao ligam pra gente</C.ProfileDescription>
          </C.ProfileCard>
          {/* Exemplo de perfil para David Correa */}
          {/* Adicione mais perfis conforme necessário */}

          {/* Botão para sair */}
          
        </C.Container>
      </C.TelaInteira>
    </>
  );
};

export default Home;

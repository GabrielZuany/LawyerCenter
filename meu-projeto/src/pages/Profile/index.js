import React, { useState, useEffect } from "react"
import { useNavigate, useParams} from "react-router-dom";
import useAuth from "../../hooks/useAuth";
import * as C from "./styles"; // Certifique-se de que os componentes estão exportados corretamente aqui
import logo from "../../img/logo.png";
import styled from 'styled-components';
import { GlobalStyle } from './styles';
import leojardim from "../../img/leojardim.png";
import { Link } from "react-router-dom";

const Profile = () => {
  const { signout } = useAuth();
  const navigate = useNavigate();
 
  const handleLogout = () => {
    signout(); // Isso irá limpar quaisquer tokens de autenticação
    navigate('/signin'); // Isso irá redirecionar o usuário para a tela de login
  };
  
  const [profileName, setProfileName] = useState("Loading...");
  const [profileType, setProfileType] = useState("Loading...");
  const [profileEmail, setProfileEmail] = useState("");
  const [profileAge, setProfileAge] = useState("");
  const [profileCity, setProfileCity] = useState("");
  const [profileState, setProfileState] = useState("");
  const [profileDescription, setProfileDescription] = useState("");
  const [profileRegisteredAt, setProfileRegisteredAt] = useState("01/01/2021");


  let { lawyerId } = useParams();

  const fetchLawyer = async () => {
    const url = `http://localhost:5001/api/v1/lawyer/getbyid?id=${lawyerId}`;
    const response = await fetch(url);
    if (!response.ok) {
      throw new Error('Network response was not ok');
    }
    const data = await response.json();
    console.log('API Response:', data);
      setProfileAge(data.age);
      setProfileCity(data.city);
      setProfileEmail(data.email);
      setProfileDescription(data.description);
      setProfileName(data.name);
      setProfileState(data.state);
      setProfileRegisteredAt(data.registrationDate);
  };
  useEffect(() => {
    fetchLawyer();
  }, []);

  return (
    <>
      <GlobalStyle />
      <C.LogoutButton onClick={handleLogout}>SAIR</C.LogoutButton>
      <C.logo
          src={logo}
          alt="logo"
          onClick={() => navigate("/home/" + null)} // Adicione esta linha
        />
      <C.TopBar />
      <C.Container>
        <C.ProfileCard>
          <C.ProfileImage src={leojardim} alt="Leo Jardim" />
          <C.ProfileName>
            {profileName}
            <C.ProfileDetails>Área: {profileType}</C.ProfileDetails>
          </C.ProfileName>
          <C.Button onClick={() => navigate('/profile')}>Entrar em contato</C.Button>
        </C.ProfileCard>
        <C.InfosCard>
          <C.InfoTitle>Email:</C.InfoTitle>
          <C.InfoText>{profileEmail}</C.InfoText>
          <C.InfoTitle>Idade:</C.InfoTitle>
          <C.InfoText>{profileAge} anos</C.InfoText>
          <C.InfoTitle>Cidade:</C.InfoTitle>
          <C.InfoText>{profileCity} - {profileState}</C.InfoText>
        </C.InfosCard>
        <C.InfoSobre>
          <C.InfoTitle>Sobre:</C.InfoTitle>
          <C.InfoText>{profileDescription}</C.InfoText>
        </C.InfoSobre>
        <C.InfoAtuacao>
          <C.InfoTitle>Registrado desde:</C.InfoTitle>
          <C.InfoText>{profileRegisteredAt.replace('T00:00:00', '').replace('-', '/').replace('-', '/')}</C.InfoText>
        </C.InfoAtuacao>
      </C.Container>
    </>
  );
};

export default Profile;

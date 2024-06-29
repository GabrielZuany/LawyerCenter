import { useNavigate, useParams } from "react-router-dom";
import useAuth from "../../hooks/useAuth";
import * as C from "./styles"; // Certifique-se de que os componentes estão exportados corretamente aqui
import logo from "../../img/logo.png";
import styled from 'styled-components';
import { GlobalStyle } from './styles';
import leojardim from "../../img/leojardim.png";
import React, { useState, useEffect } from 'react';

const LawyerHome = () => {
  const { signout } = useAuth();
  const navigate = useNavigate();
 
  const handleLogout = () => {
    signout(); // Isso irá limpar quaisquer tokens de autenticação
    navigate('/signin'); // Isso irá redirecionar o usuário para a tela de login
  };

  let { lawyerId } = useParams();
  console.log(lawyerId);

  const [name, setName] = useState("Loading...");
  const [lawyerCategoryId, setLawyerCategoryId] = useState("");
  const [profileType, setProfileType] = useState("Loading...");
  const [email, setEmail] = useState("");
  const [state, setState] = useState("");
  const [city, setCity] = useState("");
  const [photo, setPhoto] = useState("");
  const [description, setDescription] = useState("");
  const [age, setAge] = useState(0);
  const [profileRegisteredAt, setProfileRegisteredAt] = useState("01/01/2021");
  
  const fetchLawyers = async () => {
      
      const url =  `http://localhost:5001/api/v1/lawyer/getbyid?id=${lawyerId}`;
      const response = await fetch(url);
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      const data = await response.json();
      
      console.log('API Response:', data);
      setName(data.name);
      setLawyerCategoryId(data.lawyerCategoryId);
      setState(data.state);
      setCity(data.city);
      setPhoto(data.photo);
      setEmail(data.email);
      setDescription(data.description);
      setAge(data.age);
      setProfileRegisteredAt(data.registrationDate);

      const categoryResponse = await fetch(`http://localhost:5001/api/v1/lawyer/get-category?lawyerId=${lawyerId}`);
      if (!categoryResponse.ok) { throw new Error('Network response was not ok'); }
      const categoryResponseData = await categoryResponse.json();
      setProfileType(categoryResponseData.alias);
  };
  useEffect(() => {
    fetchLawyers();
  }, []);

  return (
    <>
      <GlobalStyle />
      <C.LogoutButton onClick={handleLogout}>SAIR</C.LogoutButton>
      <C.logo src = {logo} alt="logo" title="logo"/>
      <C.TopBar />
      <C.TelaInteira>
        <C.Chat> 
            <C.ChatCard>
                <C.ElementChat>Editar perfil</C.ElementChat>
            </C.ChatCard>
            <C.ChatCard>
                <C.ElementChat>Chat</C.ElementChat>
            </C.ChatCard>
            <C.ChatCard>
                <C.ElementChat>Solicitações</C.ElementChat>
            </C.ChatCard>
        </C.Chat>
        <C.Container>
            <C.ProfileCard>
                <C.ProfileImage src={leojardim} alt="Leo Jardim" />
                <C.ProfileName>
                  {name}
                  <C.ProfileDetails>Área: {profileType}</C.ProfileDetails>
                </C.ProfileName>
                
            </C.ProfileCard>
            <C.InfosCard> 
                <C.Info>
                    <C.InfoTitle>Email:</C.InfoTitle>
                    <C.InfoText>{email}</C.InfoText>
                    <C.InfoTitle>Idade:</C.InfoTitle>
                    <C.InfoText>{age} anos</C.InfoText>
                    <C.InfoTitle>Cidade:</C.InfoTitle>
                    <C.InfoText>{city} - {state}</C.InfoText>
                </C.Info>
            </C.InfosCard>
            <C.InfoSobre>
                    <C.InfoTitle>Sobre:</C.InfoTitle>
                    <C.InfoText>{description}
                    </C.InfoText>
            </C.InfoSobre>
            <C.InfoAtuacao>
                <C.Info>
                    <C.InfoTitle>Áreas de atuação:</C.InfoTitle>
                    <C.InfoText>
                      {profileRegisteredAt.replace('T00:00:00', '').replace('-', '/').replace('-', '/')}
                    </C.InfoText>
                </C.Info>
            </C.InfoAtuacao>
        </C.Container>
    </C.TelaInteira>
    </>
  );
};

export default LawyerHome;

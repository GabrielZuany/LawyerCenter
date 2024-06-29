import styled from "styled-components";
import { createGlobalStyle } from 'styled-components';

export const GlobalStyle = createGlobalStyle`
  body {
    overflow: hidden;
    margin: 0;
    padding: 0;
  }
`

export const Container = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  padding-left: 0vh;
  height: 100vh;
  width: 100vw; // Adicionado para ocupar toda a largura da tela
  overflow: hidden; // Adicionado para evitar rolagem
  background-color: #F5F5F5; // Altere para a cor de fundo desejada
`;
export const Select = styled.select`
  display: flex;
  border: none; // Remove a borda
  font-size: 1.5vh; // Torna o texto maior
  background-color: #f3f3f3; // Muda a cor de fundo para cinza claro
  padding: 1vh; // Adiciona algum preenchimento para torná-lo maior
  border-radius: 0.6vh; // Adiciona bordas arredondadas
`;
export const SearchCard = styled.div`
  height: 44.5vh;
  display: flex;
  flex-direction: line;
  margin-left: 3vh;
  margin-top: 2vh;
  width: 100%;
  max-width: 32vh;
  padding-left: 2vh; //distancia no inicio do bloco
  background-color: #FFF; // Altere para a cor de fundo desejada
  box-shadow: 0vh 0.5vh 1vh rgba(0, 0, 0, 0.1); // Altere para a sombra desejada
  border-radius: 1vh; // Altere para o raio de borda desejado
  margin-bottom: 55vh;
`;

export const SearchFiltro = styled.div`
  margin-left: 1vh;
  margin-top: 2vh;
  color: #333; // Altere para a cor desejada
`;

export const SearchSelecionavel = styled.div`
  margin-left: 1vh;
  margin-top: 1vh;
  margin-bottom: 1vh;
`;

export const TelaInteira = styled.div`
  display: flex;
  flex-direction: line;
  justify-content: flex-start;
  padding-left: 0vh;
  height: 100vh;
  width: 100vw; // Adicionado para ocupar toda a largura da tela
  overflow: hidden; // Adicionado para evitar rolagem
  background-color: #F5F5F5; // Altere para a cor de fundo desejada
`;

export const ProfileCard = styled.div`
  margin-left: 15vh;
  margin-top: 2vh;
  display: flex;
  flex-direction: line;
  align-items: left;
  width: 90%;
  height: 25vh;
  max-width: 144.4vh;
  padding: 4vh;
  max-padding: 5vh;
  background-color: #FFF; // Altere para a cor de fundo desejada
  box-shadow: 0vh 0.5vh 1vh rgba(0, 0, 0, 0.1); // Altere para a sombra desejada
  border-radius: 1vh; // Altere para o raio de borda desejado
  margin-bottom: 1vh;
  gap: 1vh;
`;

export const ProfileImage = styled.img`
  margin-top: -2vh;
  width: 20vh;
  height: 20vh;
  border-radius: 50%;
  object-fit: cover;
`;

export const ProfileName = styled.h2`
  margin-left: 2vh;
  font-size: 2vh;
  font-weight: bold;
  color: #333; // Altere para a cor desejada
  margin-top: 1vh;
  max-width: 16.6vh;
`;

export const ProfileDetails = styled.p`
  margin-top: 1vh;
  font-size: 1.7vh;
  color: #1C1C1C; // Altere para a cor desejada
`;

export const ProfileDescription = styled.p`
  position: center;
  margin-left: 20.3vh;
  font-size: 1.5vh;
  color: #1D1D1D; // Altere para a cor desejada
  max-width: 52.5vh;
  margin-top: 1vh;
`;

export const TopBar = styled.div`
  width: 100%;
  height: 9vh; // Ajuste a altura conforme necessário
  background-color: #1C1C1C; // Ajuste a cor conforme necessário
  positon: fixed
  top: 0;
  left: 0;
  z-index: 1000; // Isso garante que a barra esteja sempre no topo
`;
export const logo = styled.img`
  position: absolute;
  width: 17.15vh; /* Defina a largura desejada */
  height: 10.4vh; /* Mantém a proporção da imagem */
  display: block; /* Garante que a imagem seja um bloco */
  margin-left: 0.8vh;
  margin-top: -0.6vh;
`;
export const LogoutButton = styled.button`
  position: absolute;
  right: 10vh; // Ajuste conforme necessário
  top: 3vh; // Ajuste conforme necessário
  background: none;
  color: #FFFFFF; /* Cor do texto */
  border: none;
  cursor: pointer;
  font-size: 2vh; /* Ajuste o tamanho da fonte conforme necessário */
  &:hover {
    opacity: 0.8;
  }
`;

export const RadioButton = styled.label`
  display: block; // Adicionado para alinhar os botões verticalmente
  position: relative;
  padding-left: 4vh;
  margin: 1.4vh auto; // Adicionado para centralizar os botões
  cursor: pointer;
  font-size: 2vh;
  user-select: none;

  input {
    position: absolute;
    opacity: 0;
    cursor: pointer;
  }

  .checkmark {
    position: absolute;
    top: 0;
    left: 0;
    height: 2vh;
    width: 2vh;
    background-color: #eee;
    border-radius: 50%;
  }

  input:checked ~ .checkmark {
    background-color: #2196F3;
  }

  .checkmark:after {
    content: "";
    position: absolute;
    display: none;
  }

  input:checked ~ .checkmark:after {
    display: block;
  }

  .checkmark:after {
    top: 50%;
    left: 50%;
    width: 1vh;
    height: 1vh;
    border-radius: 50%;
    background: white;
    transform: translate(-50%, -50%); // Adicionado para centralizar o círculo interno
  }
`;

export const SearchTitle = styled.h1`
  font-size: 2vh; // Ajuste o tamanho conforme necessário
  font-weight: bold;
`;

export const ProfileButton = styled.button`
    background: none;
    border: none;
    color: blue;
    cursor: pointer;

    &:hover {
        opacity: 0.7;
    }
`;

export const Button = styled.button`
  margin-top: 1.3vh;
  margin-left: 97vh;
  padding: 1.7vh;
  outline: none;
  border: none;
  border-radius: 0.5vh;
  width: 17vh;
  cursor: pointer;
  background-color: #046ee5;
  color: white;
  font-weight: 20vh;
  font-size: 1.5vh;
  max-width: 38.9vh;
`;
export const PageButton = styled.button`
  margin: 0 5px;
  padding: 5px 10px;
  background-color: ${({ active }) => (active ? '#ccc' : '#fff')};
  border: 1px solid #000;
  border-radius: 5px;
  cursor: pointer;

  &:hover {
    background-color: #eee;
  }
`;

export const ArrowButton = styled.button`
  margin: 0 10px;
  padding: 5px 10px;
  background-color: #fff;
  border: 1px solid #000;
  border-radius: 5px;
  cursor: pointer;

  &:disabled {
    cursor: not-allowed;
    opacity: 0.5;
  }
`;
export const ContainerPagination = styled.div`
  margin-top: 1.5vh;
  margin-left: 71.6vh;
`;


export const CardVazio = styled.button`
  border: none; 
  background-color: #F5F5F5;
  margin-left: 15vh;
  margin-top: 2vh;
  display: flex;
  flex-direction: line;
  align-items: left;
  width: 90%;
  height: 26vh;
  max-width: 144.4vh;
  padding: 4vh;
  max-padding: 5vh;
  border-radius: 1vh; // Altere para o raio de borda desejado
  gap: 1.2vh;
`;

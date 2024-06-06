import styled from "styled-components";

export const Container = styled.div`
  display: flex;
  align-items: center;
  align-content: center;
  justify-content: center;
  flex-direction: row;
  gap: 200px;
  height: 90vh;
`;

export const Content = styled.div`
  gap: 15px;
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
  width: 100%;
  box-shadow: 0 1px 2px #0003;
  background-color: white;
  max-width: 350px;
  padding: 30px;
  border-radius: 10px;
`;

export const Label = styled.label`
  font-size: 18px;
  font-weight: 600;
  color: #676767;
`;

export const LabelSignin = styled.label`
  font-size: 16px;
  color: #676767;
`;

export const labelError = styled.label`
  font-size: 14px;
  color: red;
`;

export const Strong = styled.strong`
  cursor: pointer;

  a {
    text-decoration: none;
    color: #676767;
  }
`;

export const Logozinho = styled.img`
  width: 170px; /* Defina a largura desejada */
  height: 32px; /* Mantém a proporção da imagem */
  display: block; /* Garante que a imagem seja um bloco */
  margin-left: 0px;/
  margin-top: 0px;
`;

export const Logo_centro = styled.img`
  width: 214px; /* Defina a largura desejada */
  height: 670px; /* Mantém a proporção da imagem */
  display: block; /* Garante que a imagem seja um bloco */
  margin-left: 0px;
  margin-top: 0px;
`;

 
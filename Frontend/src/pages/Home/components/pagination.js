import React from 'react';
import { ContainerPagination, PageButton, ArrowButton } from './styles';

const Pagination = ({ totalPages, currentPage, onPageChange }) => {
  const maxButtons = 5;

  const handlePageClick = (pageNumber) => {
    onPageChange(pageNumber);
  };

  const getPageNumbers = () => {
    let startPage, endPage;

    if (totalPages <= maxButtons) {
      startPage = 1;
      endPage = totalPages;
    } else {
      if (currentPage <= Math.ceil(maxButtons / 2)) {
        startPage = 1;
        endPage = maxButtons;
      } else if (currentPage > totalPages - Math.floor(maxButtons / 2)) {
        startPage = totalPages - maxButtons + 1;
        endPage = totalPages;
      } else {
        startPage = currentPage - Math.floor(maxButtons / 2);
        endPage = currentPage + Math.floor(maxButtons / 2);
      }
    }

    if (startPage < 1) {
      startPage = 1;
      endPage = maxButtons;
    }

    if (endPage > totalPages) {
      endPage = totalPages;
      startPage = totalPages - maxButtons + 1;
      if (startPage < 1) startPage = 1;
    }

    return Array.from({ length: (endPage + 1) - startPage }, (_, index) => startPage + index);
  };

  const pageNumbers = getPageNumbers();
  const isLastButtonVisible = pageNumbers[pageNumbers.length - 1] === totalPages;

  return (
    <ContainerPagination>
      <ArrowButton
        onClick={() => handlePageClick(currentPage - 1)}
        disabled={currentPage === 1}
      >
        &laquo;
      </ArrowButton>
      {pageNumbers.map(number => (
        <PageButton
          key={number}
          onClick={() => handlePageClick(number)}
          active={currentPage === number}
        >
          {number}
        </PageButton>
      ))}
      <ArrowButton
        onClick={() => handlePageClick(currentPage + 1)}
        disabled={isLastButtonVisible || currentPage === totalPages}
      >
        &raquo;
      </ArrowButton>
    </ContainerPagination>
  );
};

export default Pagination;

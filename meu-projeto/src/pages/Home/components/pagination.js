import React, { useState } from 'react';
import { ContainerPagination, PageButton, ArrowButton } from './styles';

const Pagination = ({ totalPages, currentPage, onPageChange } ) => {
  // const [currentPage, setCurrentPage] = useState(1);

  const handlePageClick = (pageNumber) => {
    onPageChange(pageNumber);
  };

  const getPageNumbers = () => {
    let startPage, endPage;
    if (totalPages <= 5) {
      // less than 5 total pages, so show all pages
      startPage = 1;
      endPage = totalPages;
    } else {
      // more than 5 total pages, so calculate start and end pages
      if (currentPage <= 3) {
        startPage = 1;
        endPage = 5;
      } else if (currentPage + 2 >= totalPages) {
        startPage = totalPages - 4;
        endPage = totalPages;
      } else {
        startPage = currentPage - 2;
        endPage = currentPage + 2;
      }
    }
    return Array.from({ length: (endPage + 1) - startPage }, (_, index) => startPage + index);
  };

  const pageNumbers = getPageNumbers();

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
        disabled={currentPage === totalPages}
      >
        &raquo;
      </ArrowButton>
    </ContainerPagination>
  );
};

export default Pagination;

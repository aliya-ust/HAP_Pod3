export interface ApiResponse<T> {
  success: boolean;
  message: string;
  data: T;
  errors: string[] | null;
}

export interface PagedResult<T> {
  items: T[];
  pageNumber: number;
  pageSize: number;
  totalCount: number;
  totalPages: number;
}

export interface PaginationParams {
  pageNumber?: number;
  pageSize?: number;
}

export interface ErrorResponse {
  statusCode: number;
  message: string;
  details: string | null;
  timestamp: string;
  path: string;
}
